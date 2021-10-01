using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VP.Nest.Economy;
using VP.Nest.Utilities;

namespace VP.Nest.UI.Currency
{
	public class CurrencyUI : MonoBehaviour
	{
		private MoneyIconGroup moneyIconGroup;
		private TextMeshProUGUI moneyText;

		private bool isMoneyCounting;

		private Camera cam;

		[SerializeField] private Transform target;
		[SerializeField] private GameObject moneyIconPrefab;

		private void OnEnable()
		{
			GameEconomy.OnPlayerMoneyUpdate += OnPlayerMoneyUpdate;
		}

		private void OnPlayerMoneyUpdate(int newMoney, bool isSpend)
		{
#if UNITY_EDITOR
			Debug.Log("Money Updated " + newMoney);
#endif
		}

		private void Awake()
		{
			moneyIconGroup = GetComponentInChildren<MoneyIconGroup>(true);
			moneyText = transform.Find("PlayerMoney").GetComponentInChildren<TextMeshProUGUI>(true);
			moneyText.SetText(GameEconomy.PlayerMoney.ToString());

			ObjectPooler.Instance.AddToPool("MoneyIcon", moneyIconPrefab, 30);

			cam = Camera.main;
		}

		[ContextMenu("Add 100 Money")]
		private void Add()
		{
			AddMoney(100);
		}

		[ContextMenu("Spend 50 Money")]
		private void Spend()
		{
			SpendMoney(50);
		}

		/// <summary>
		/// Adds money and plays a scattered animation
		/// </summary>
		/// <param name="amount">Amount of money you want to add</param>
		public void AddMoney(int amount)
		{
			if (isMoneyCounting)
			{
#if UNITY_EDITOR
				Debug.Log("Money Already Counting , Cannot add money !!");
#endif
				return;
			}

			StartCoroutine(AddMoneyCoroutine(amount));
		}

		/// <summary>
		/// Adds money and plays an harmonious animation that starts at given position
		/// </summary>
		/// <param name="amount">Amount of money you want to add</param>
		/// <param name="from">The position that animation will be played from</param>	
		/// <param name="multiple">Will the animated icons be more than one? (Default is false)</param>
		public void AddMoney(int amount, Vector3 from, bool multiple = false)
		{
			if (amount.Equals(0)) return;
			StartCoroutine(AddMoneyCoroutine(amount, from, multiple));
		}

		private IEnumerator AddMoneyCoroutine(int amount)
		{
			float currentMoney = GameEconomy.PlayerMoney;
			float nextMoney = currentMoney + amount;
			isMoneyCounting = true;

			GameEconomy.AdjustPlayerMoney(amount);

			moneyIconGroup.Init();
			yield return new WaitForSeconds(1.25f);
			yield return DOTween.To(() => currentMoney, x => currentMoney = x, nextMoney, 1).OnUpdate(() =>
				moneyText.SetText(Mathf.CeilToInt(currentMoney).ToString())).SetEase(Ease.OutCubic).WaitForCompletion();

			isMoneyCounting = false;
		}

		private IEnumerator AddMoneyCoroutine(int amount, Vector3 fromPosition, bool multiple = false)
		{
			float currentMoney = GameEconomy.PlayerMoney;
			float nextMoney = currentMoney + amount;
			GameEconomy.AdjustPlayerMoney(amount);

			Vector3 pos = cam.WorldToScreenPoint(fromPosition);

			int count = multiple ? Mathf.Clamp(amount, 1, 10) : 1;
			for (int i = 0; i < count; i++)
			{
				GameObject icon = ObjectPooler.Instance.Spawn("MoneyIcon", pos, transform);
				icon.transform.DOMove(target.position, 1).SetEase(Ease.InBack).SetId("icon").OnComplete(() =>
				{
					target.DOComplete();
					target.DOPunchScale(Vector3.one * .9f, .2f, 2, .5f);
					icon.gameObject.SetActive(false);

					moneyText.SetText(Mathf.CeilToInt(Mathf.Lerp(int.Parse(moneyText.text), nextMoney, .5f)).ToString());
				});

				yield return UsefulFunctions.BetterWaitForSeconds.WaitRealtime(.04f);
			}

			moneyText.SetText(Mathf.CeilToInt(nextMoney).ToString());
		}

		/// <summary>
		/// Spends the money by given amount
		/// </summary>
		/// <param name="amount">The amount of money will be spent</param>
		public void SpendMoney(int amount)
		{
			float currentMoney = GameEconomy.PlayerMoney;
			float nextMoney = currentMoney - amount;
			isMoneyCounting = true;

			GameEconomy.AdjustPlayerMoney(-amount);

			DOTween.Complete("SpendMoney");
			DOTween.To(() => currentMoney, x => currentMoney = x, nextMoney, 1).SetId("SpendMoney").SetEase(Ease.OutCubic)
				.OnUpdate(() => moneyText.SetText(Mathf.CeilToInt(currentMoney).ToString()))
				.OnComplete(() => isMoneyCounting = false);
		}

		private void OnDisable()
		{
			GameEconomy.OnPlayerMoneyUpdate -= OnPlayerMoneyUpdate;
		}
	}
}